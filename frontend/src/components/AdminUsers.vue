<template>
  <div class="users-page">
    <h2>User Management</h2>
    <table class="users-table">
      <thead>
        <tr>
          <th>Email</th>
          <th>Name</th>
          <th>Role</th>
          <th>Status</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in users" :key="user.email">
          <td>{{ user.email }}</td>
          <td>{{ user.name }}</td>
          <td>{{ user.role }}</td>
          <td><span :class="user.status">{{ user.status }}</span></td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: 'AdminUsers',
  data() {
    return {
      users: [
        { email: 'admin@example.com', name: 'Admin User', role: 'admin', status: 'active' },
        { email: 'user@example.com', name: 'John Doe', role: 'employee', status: 'active' },
        { email: 'jane@hais.com', name: 'Jane Smith', role: 'employee', status: 'inactive' }
      ]
    }
  }
}
</script>

<style scoped>
.users-page {
  margin-left: 240px;
  padding: 2rem;
}
.users-table {
  width: 100%;
  border-collapse: collapse;
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 8px rgba(31,38,135,0.07);
  overflow: hidden;
}
th, td {
  padding: 1rem;
  text-align: left;
}
th {
  background: #e0eafc;
  color: #1a7ca7;
}
tr:not(:last-child) {
  border-bottom: 1px solid #eee;
}
.active {
  color: #27ae60;
}
.inactive {
  color: #e74c3c;
}
</style>
