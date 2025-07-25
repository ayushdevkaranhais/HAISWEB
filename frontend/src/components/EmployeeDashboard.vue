<template>
  <div class="dashboard-container">
    <EmployeeSidebar :selected="selected" @navigate="selected = $event" @logout="logout" />
    <main>
      <EmployeeProfile v-if="selected === 'profile'" :email="email" />
      <EmployeeTasks v-else-if="selected === 'tasks'" />
      <EmployeeAnnouncements v-else-if="selected === 'announcements'" />
      <div v-else class="dashboard-welcome">
        <h2>Welcome, {{ email }} (Employee)</h2>
        <p>This is your employee dashboard. Use the sidebar to navigate.</p>
      </div>
    </main>
  </div>
</template>

<script>
import EmployeeSidebar from './EmployeeSidebar.vue';
import EmployeeProfile from './EmployeeProfile.vue';
import EmployeeTasks from './EmployeeTasks.vue';
import EmployeeAnnouncements from './EmployeeAnnouncements.vue';

export default {
  name: 'EmployeeDashboard',
  components: { EmployeeSidebar, EmployeeProfile, EmployeeTasks, EmployeeAnnouncements },
  props: ['email'],
  data() {
    return {
      selected: 'dashboard'
    }
  },
  methods: {
    logout() {
      this.$emit('logout');
    }
  }
}
</script>

<style scoped>
main {
  margin-left: 240px;
  padding: 2rem;
}
.dashboard-welcome {
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 8px rgba(31,38,135,0.07);
  padding: 2rem;
  max-width: 600px;
}
</style>
