<template>
  <div class="dashboard-container">
    <header class="dashboard-header">
      <h1>HAISWEB Dashboard</h1>
      <button @click="logout">Logout</button>
    </header>
    <main>
      <h2>Welcome, {{ username }}!</h2>
      <p>This is your beautiful dashboard. (You can add widgets, stats, and more here.)</p>
      <div class="dashboard-welcome">
        <img src="https://cdn-icons-png.flaticon.com/512/5087/5087579.png" alt="Dashboard" />
        <div class="dashboard-info">
          <h3>Project User Stories</h3>
          <p>User stories are fetched and saved in the backend. You can extend this dashboard to display, search, or manage them as needed.</p>
        </div>
      </div>
    </main>
  </div>
</template>

<script>
export default {
  name: 'DashboardPage',
  props: ['username'],
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
.dashboard-welcome {
  display: flex;
  align-items: center;
  justify-content: center;
  margin-top: 2rem;
}
.dashboard-welcome img {
  width: 100px;
  margin-right: 2rem;
}
.dashboard-info {
  text-align: left;
}
</style>
