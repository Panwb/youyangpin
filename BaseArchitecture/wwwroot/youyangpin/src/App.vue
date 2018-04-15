<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #333;
  background:#fff;
}
*{
  margin:0;
  padding:0;
}
a{
  text-decoration:none;
}
.wd1200{
  width:1200px;
  margin:0 auto;
}
</style>
