<template>
  <div class="dashboard-container">
    <AdminSidebar :selected="selected" @navigate="selected = $event" @logout="logout" />
    <main>
      <AdminUsers v-if="selected === 'users'" />
      <AdminReports v-else-if="selected === 'reports'" />
      <AdminSettings v-else-if="selected === 'settings'" />
      <div v-else class="dashboard-welcome">
        <h2>Welcome, {{ email }} (Admin)</h2>
        <p>This is your admin dashboard. Use the sidebar to navigate.</p>
      </div>
    </main>
  </div>
</template>

<script>
import AdminSidebar from './AdminSidebar.vue';
import AdminUsers from './AdminUsers.vue';
import AdminReports from './AdminReports.vue';
import AdminSettings from './AdminSettings.vue';

export default {
  name: 'AdminDashboard',
  components: { AdminSidebar, AdminUsers, AdminReports, AdminSettings },
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
