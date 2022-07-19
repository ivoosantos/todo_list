<template>
  <div class="todolist">
    <header>
        <h2>Vue.js Todo List</h2>
        <form>
            <input type="text" v-model="currentTodo" placeholder="Description" maxlength="500">
            <button @click.prevent="addTodo">+</button>
        </form>
    </header>

    <section>
        <ol>
            <li v-for="todo in filteredTodos" :key="todo.text" v-on:click="toggleTodo(todo)">
                <div>
                    <input type="checkbox" v-bind:checked="todo.done">

                    <label>
                        <del v-if="todo.done">
                            {{ todo.text }}
                        </del>
                        <span v-else>
                      {{ todo.text }}
                    </span>
                    </label>
                </div>

                <img src="../assets/close-icon.png" @click="delTodo(todo)" alt="fechar">
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
    name: 'HelloWorld',
    data: () => ({
        currentTodo: "",
        todos: [
            { text: "Learn Vue", done: false },
            { text: "Learn Java", done: false },
            { text: "Play with friends", done: true }
        ],
        to_do: String
    }),
    methods: {
        toggleTodo(todo) {
            todo.done = !todo.done,
            this.sortTodos()
        },
        addTodo() {
            if(!this.currentTodo.trim() || this.checkIfTodoExists()) return
            this.todos.push({
                text: this.currentTodo,
                done: false
            });
            this.currentTodo = ""
            this.sortTodos()
        },
        delTodo(todo) {
            this.todos = this.todos.filter(el => el.text !== todo.text)
        },
        sortTodos() {
            this.todos.sort((a,b) => a.done - b.done)
        },
        checkIfTodoExists() {
            return this.todos.some((todo) => todo.text === this.currentTodo.trim())
        },
        getTodo() {
          axios
            .get("/todos").then((res) => {
              this.todos = res.data;
            })
            .catch((error) => {
              console.log(error);
            })
        },
        insertTodo() {
          axios
            .get().then((res) => {
              this.to_do = res.data;
            }).catch((error) => {
              console.log(error);
            });
        },
        deletarTodo(id) {
          axios
            .delete(`/todo/${id}`).then(() => {
              console.log('Todo deletado com sucesso!')
            })
            .catch((error) => {
              console.log(error);
            })
        }
    },
    computed: {
        filteredTodos() {
            return this.todos.filter(
                todo => todo.text.toLowerCase().match(this.currentTodo.toLowerCase())
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
    background: #fff;
    border-radius: 4px;
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
