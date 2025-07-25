<template>
  <div class="settings-page">
    <h2>System Settings</h2>
    <div class="settings-card">
      <div class="settings-row"><strong>Theme:</strong> Light</div>
      <div class="settings-row"><strong>Notifications:</strong> Enabled</div>
      <div class="settings-row"><strong>Version:</strong> 1.0.0</div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'AdminSettings'
}
</script>

<style scoped>
.settings-page {
  margin-left: 240px;
  padding: 2rem;
}
.settings-card {
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 8px rgba(31,38,135,0.07);
  padding: 2rem;
  max-width: 400px;
}
.settings-row {
  margin-bottom: 1rem;
  font-size: 1.1rem;
}
</style>
