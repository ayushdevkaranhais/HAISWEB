<template>
  <div class="profile-page">
    <h2>My Profile</h2>
    <div class="profile-card">
      <div class="profile-row"><strong>Email:</strong> {{ email }}</div>
      <div class="profile-row"><strong>Name:</strong> John Doe</div>
      <div class="profile-row"><strong>Role:</strong> Employee</div>
      <div class="profile-row"><strong>Department:</strong> Engineering</div>
      <div class="profile-row"><strong>Phone:</strong> +91-9876543210</div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'EmployeeProfile',
  props: ['email']
}
</script>

<style scoped>
.profile-page {
  margin-left: 240px;
  padding: 2rem;
}
.profile-card {
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 8px rgba(31,38,135,0.07);
  padding: 2rem;
  max-width: 400px;
}
.profile-row {
  margin-bottom: 1rem;
  font-size: 1.1rem;
}
</style>
