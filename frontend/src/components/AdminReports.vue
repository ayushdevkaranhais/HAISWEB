<template>
  <div class="reports-page">
    <h2>Reports</h2>
    <div class="report-card">
      <h3>Employee Activity</h3>
      <p>Active Employees: 12</p>
      <p>Inactive Employees: 3</p>
    </div>
    <div class="report-card">
      <h3>System Usage</h3>
      <p>Logins Today: 8</p>
      <p>Tasks Completed: 15</p>
    </div>
  </div>
</template>

<script>
export default {
  name: 'AdminReports'
}
</script>

<style scoped>
.reports-page {
  margin-left: 240px;
  padding: 2rem;
}
.report-card {
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 8px rgba(31,38,135,0.07);
  padding: 1.5rem;
  margin-bottom: 1.5rem;
  max-width: 400px;
}
</style>
