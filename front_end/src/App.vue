<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'

export default {
  name: 'App',
  components: {
    HelloWorld
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
    background: #4fc08d;
    font-family: Helvetica;
    width: 80%;
    margin: auto;
}


</style>
