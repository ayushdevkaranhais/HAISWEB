<template>
  <nav class="sidebar">
    <ul>
      <li :class="{active: selected === 'dashboard'}" @click="$emit('navigate', 'dashboard')">
        <i class="fas fa-home"></i> Dashboard
      </li>
      <li :class="{active: selected === 'profile'}" @click="$emit('navigate', 'profile')">
        <i class="fas fa-user"></i> Profile
      </li>
      <li :class="{active: selected === 'tasks'}" @click="$emit('navigate', 'tasks')">
        <i class="fas fa-tasks"></i> Tasks
      </li>
      <li :class="{active: selected === 'announcements'}" @click="$emit('navigate', 'announcements')">
        <i class="fas fa-bullhorn"></i> Announcements
      </li>
      <li class="logout" @click="$emit('logout')">
        <i class="fas fa-sign-out-alt"></i> Logout
      </li>
    </ul>
  </nav>
</template>

<script>
export default {
  name: 'EmployeeSidebar',
  props: ['selected']
}
</script>

<style scoped>
.sidebar {
  width: 220px;
  background: #fff;
  min-height: 100vh;
  box-shadow: 2px 0 8px rgba(31,38,135,0.07);
  padding-top: 2rem;
  position: fixed;
  left: 0;
  top: 0;
}
ul {
  list-style: none;
  padding: 0;
  margin: 0;
}
li {
  padding: 1rem 2rem;
  color: #1a7ca7;
  font-size: 1.1rem;
  cursor: pointer;
  display: flex;
  align-items: center;
  transition: background 0.2s, color 0.2s;
}
li i {
  margin-right: 1rem;
}
li.active, li:hover {
  background: #e0eafc;
  color: #38b6ff;
}
li.logout {
  color: #e74c3c;
  margin-top: 2rem;
}
</style>
