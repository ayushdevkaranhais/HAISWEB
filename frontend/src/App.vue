<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App" />
    <p>Backend response: {{ message }}</p>
    <div>
      <h2>User Stories from OpenProject</h2>
      <ul>
        <li v-for="story in userStories" :key="story.id">
          <strong>{{ story.subject }}</strong><br />
          <em>{{ story.description }}</em>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'

export default {
  name: 'App',
  components: {
    HelloWorld
  },
  data() {
    return {
      message: 'Loading...',
      userStories: []
    }
  },
  mounted() {
    fetch('/api/test')
      .then(response => response.text())
      .then(data => {
        this.message = data;
      })
      .catch(error => {
        console.error("Error calling backend:", error);
        this.message = 'Failed to fetch from backend';
      });

    // Fetch user stories from backend
    fetch('/api/OpenProject/userstories')
      .then(response => response.json())
      .then(data => {
        this.userStories = data;
      })
      .catch(error => {
        console.error("Error fetching user stories:", error);
      });
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>