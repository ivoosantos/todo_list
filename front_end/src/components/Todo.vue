<template>
  <div class="todolist">
    <header>
        <h2>Vue.js Todo List</h2>
        <form>
            <input type="text" v-model="currentTodo" placeholder="Digite sua tarefa" maxlength="500">
            <button @click.prevent="insertTodo">+</button>
        </form>
    </header>
    <p>Clique no nome da tarefa para Finalizar ou Refazer!</p>
    <section>
        <ol>
            <li v-for="todo in lista" :key="todo.id">
                <div>
                    <label v-on:click="tarefaFeita(todo)">
                        <del v-if="todo.finalizado">
                            {{ todo.todo }}
                        </del>
                        <span v-else>
                            {{ todo.todo }}
                        </span>
                    </label>
                </div>

                <img src="../assets/close-icon.png" @click="deletarTodo(todo.id)" alt="fechar">
            </li>
        </ol>
    </section>
  </div>
</template>

<script>
import axios from "axios";
// new Vue({
    // el: "#app",
  export default {
    name: 'Todo',
    data: () => ({
        currentTodo: "",
        to_do: String,
        lista: [],
        tarefa: {
            todo: '',
            finalizado: false
        }
    }),
    mounted () {
        this.getTodo()
    },
    watch: {
        options: {
            handler () {
                this.getTodo()
            },
            deep: true
        }
    },
    methods: {
        checkIfTodoExists() {
            return this.lista.some((todo) => todo.todo === this.currentTodo.trim())
        },
        getTodo() {
          axios
            .get("https://localhost:44359/api/getall").then((res) => {
              this.lista = res.data;
            })
            .catch((error) => {
              console.log(error);
            })
        },
        insertTodo() {
            if(!this.currentTodo.trim() || this.checkIfTodoExists()) 
                return
          axios
            .post("https://localhost:44359/api", {todo: this.currentTodo, finalizado: false}).then((res) => {
              this.to_do = res.data;
              console.log('To-do cadastrado com sucesso!')
              this.getTodo()
            }).catch((error) => {
              console.log(error);
            });
        },
        deletarTodo(id) {
          axios
            .delete(`https://localhost:44359/api/${id}`).then(() => {
              console.log('Todo deletado com sucesso!')
              this.getTodo()
            })
            .catch((error) => {
              console.log(error);
            })
        },
        tarefaFeita(todo) {
            if(!todo.finalizado){
                axios
                    .put(`https://localhost:44359/api/finalizar/${todo.id}`).then(() => {
                    console.log('Tarefa feita com sucesso!')
                    this.getTodo()
                    })
                    .catch((error) => {
                    console.log(error);
                    })
            }else{
                axios
                    .put(`https://localhost:44359/api/refazer/${todo.id}`).then(() => {
                    console.log('Tarefa para refazer!')
                    this.getTodo()
                    })
                    .catch((error) => {
                    console.log(error);
                    })
            }
            
        }
    },
    computed: {
        filteredTodos() {
            return this.lista.filter(
                lista => lista.todo.toLowerCase().match(this.currentTodo.toLowerCase())
            )
        }
    }
  }

</script>

<style scoped>
.todolist {
    display: flex;
    flex-direction: column;
    margin: 15px 5px;
    padding: 5px;
    background: rgb(206, 231, 233);
    border-radius: 4px;
}
p {
    font-weight: bold;
    color: #4fc08d;
    margin-bottom: 10px;
    margin-left: 10px;
    font-size: 1.3em;
}
h2 {
    font-weight: bold;
    color: #4fc08d;
    margin-bottom: 10px;
    margin-left: 10px;
    font-size: 1.3em;
}

form {
    display: flex;
    justify-content: flex-start;
}

del {
    color: rgba(0, 0, 0, 0.3);
}

button {
    color: #fff;
    background-color: #4fc08d;
    border-radius: 2em;
    padding: 0.4em 1em;
    border: 2px solid #4fc08d;
    transition: .2s;
    cursor: pointer;
}

input[type=text] {
    border-radius: 2em;
    padding: 0.3em 1em;
    border: 2px solid #4fc08d;
    font-family: Helvetica;
    max-width: 70%;
}

ol li {
    transition: .2s;
    border-radius: 2em;
    width: auto;
    display: flex;
    align-items: center;
    justify-content: space-between;
}

ol li:nth-child(odd) {
    background: #f9f9f9;
}

ol li:hover {
    background: #4fc08d;
}

button:hover {
    background-color: #07c56f;
}

label, img, li {
    cursor: pointer;
}

ol {
    list-style: decimal inside none;
}


@media screen and (min-width: 620px) {
    * {
        font-size: 1em;
    }
}
@media screen and (min-width: 1000px) {

    input[type=text] {
        width: 35%;
    }

    body {
        width: 60%;
    }
}

li > div {
    display: flex;
    align-items: center;
}
</style>
