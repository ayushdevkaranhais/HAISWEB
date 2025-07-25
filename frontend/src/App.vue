<template>
  <div id="app">
    <LoginPage v-if="!isAuthenticated" @login-success="onLoginSuccess" />
    <AdminDashboard v-else-if="role === 'admin'" :email="email" @logout="onLogout" />
    <EmployeeDashboard v-else :email="email" @logout="onLogout" />
  </div>
</template>

<script>

import LoginPage from './components/LoginPage.vue';
import AdminDashboard from './components/AdminDashboard.vue';
import EmployeeDashboard from './components/EmployeeDashboard.vue';

export default {
  name: 'App',
  components: {
    LoginPage,
    AdminDashboard,
    EmployeeDashboard
  },
  data() {
    return {
      isAuthenticated: false,
      email: '',
      role: ''
    }
  },
  methods: {
    onLoginSuccess({ email, role }) {
      this.isAuthenticated = true;
      this.email = email;
      this.role = role;
    },
    onLogout() {
      this.isAuthenticated = false;
      this.email = '';
      this.role = '';
    }
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
.story {
  background: #f9f9f9;
  border: 1px solid #ddd;
  border-radius: 8px;
  margin: 20px auto;
  max-width: 600px;
  padding: 20px;
  text-align: left;
}
</style>