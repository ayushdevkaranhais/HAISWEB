<template>
  <div class="dashboard-container">
    <header class="dashboard-header">
      <h1>Admin Dashboard</h1>
      <button @click="logout">Logout</button>
    </header>
    <main>
      <h2>Welcome, {{ email }} (Admin)</h2>
      <p>This is the admin dashboard. Here you can manage users, view reports, and configure the system.</p>
      <div class="dashboard-section">
        <h3>Admin Actions</h3>
        <ul>
          <li>View all employees</li>
          <li>Manage user roles</li>
          <li>System settings</li>
        </ul>
      </div>
    </main>
  </div>
</template>

<script>
export default {
  name: 'AdminDashboard',
  props: ['email'],
  methods: {
    logout() {
      this.$emit('logout');
    }
  }
}
</script>

<style scoped>
.dashboard-container {
  min-height: 100vh;
  background: linear-gradient(135deg, #e0eafc 0%, #cfdef3 100%);
}
.dashboard-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 2rem 3rem 1rem 3rem;
  background: #fff;
  box-shadow: 0 2px 8px rgba(31, 38, 135, 0.07);
}
.dashboard-header h1 {
  margin: 0;
  color: #2c3e50;
}
.dashboard-header button {
  background: #4f8cff;
  color: #fff;
  border: none;
  border-radius: 8px;
  padding: 0.5rem 1.5rem;
  font-size: 1rem;
  font-weight: bold;
  cursor: pointer;
  transition: background 0.2s;
}
.dashboard-header button:hover {
  background: #38b6ff;
}
main {
  padding: 2rem 3rem;
  text-align: center;
}
.dashboard-section {
  margin-top: 2rem;
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 8px rgba(31, 38, 135, 0.07);
  padding: 2rem;
  max-width: 600px;
  margin-left: auto;
  margin-right: auto;
}
</style>
