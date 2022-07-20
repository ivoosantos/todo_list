<template>
  <div id="app">
    <main>
      <img alt="Vue logo" src="./assets/banner.jpg">
      <Todo msg="Bem vindo ao To-do List"/>
    </main>
    
  </div>
</template>

<script>
import Todo from './components/Todo.vue'

export default {
  name: 'App',
  components: {
    Todo
  }
}
</script>

<style>
/* #app
  font-family Avenir, Helvetica, Arial, sans-serif
  -webkit-font-smoothing antialiased
  -moz-osx-font-smoothing grayscale
  text-align center
  color #2c3e50
  margin-top 60px */


* {
    box-sizing: border-box;
    margin: 5px;
    padding: 0;
    font-size: .98em;
    overflow-wrap: break-word;
    hyphens: auto;
    word-break: break-all;
    -webkit-tap-highlight-color: transparent;
}

*:focus {
    outline: none;
}

body {
    background: #ffffff;
    font-family: Helvetica;
    width: 80%;
    margin: auto;
}
</style>
