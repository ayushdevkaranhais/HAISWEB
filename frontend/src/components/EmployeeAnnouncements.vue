<template>
  <div class="announcements-page">
    <h2>Announcements</h2>
    <div class="announcement-card" v-for="a in announcements" :key="a.id">
      <div class="announcement-title">{{ a.title }}</div>
      <div class="announcement-date">{{ a.date }}</div>
      <div class="announcement-body">{{ a.body }}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'EmployeeAnnouncements',
  data() {
    return {
      announcements: [
        { id: 1, title: 'Welcome to HAIS!', date: '2025-07-25', body: 'We are excited to have you on board. Please check your tasks and complete onboarding.' },
        { id: 2, title: 'Holiday Notice', date: '2025-08-15', body: 'The office will be closed for Independence Day.' }
      ]
    }
  }
}
</script>

<style scoped>
.announcements-page {
  margin-left: 240px;
  padding: 2rem;
}
.announcement-card {
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 8px rgba(31,38,135,0.07);
  padding: 1.5rem;
  margin-bottom: 1.5rem;
  max-width: 600px;
}
.announcement-title {
  font-weight: bold;
  font-size: 1.1rem;
  margin-bottom: 0.3rem;
}
.announcement-date {
  color: #888;
  font-size: 0.95rem;
  margin-bottom: 0.5rem;
}
.announcement-body {
  font-size: 1rem;
}
</style>
