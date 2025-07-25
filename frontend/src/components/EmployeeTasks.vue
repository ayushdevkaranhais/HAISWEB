<template>
  <div class="tasks-page">
    <h2>My Tasks</h2>
    <div class="tasks-list">
      <div class="task-card" v-for="task in tasks" :key="task.id">
        <div class="task-title">{{ task.title }}</div>
        <div class="task-desc">{{ task.description }}</div>
        <div class="task-status">Status: <span :class="task.status">{{ task.status }}</span></div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'EmployeeTasks',
  data() {
    return {
      tasks: [
        { id: 1, title: 'Complete onboarding', description: 'Finish all onboarding steps in the portal.', status: 'pending' },
        { id: 2, title: 'Submit documents', description: 'Upload your ID and address proof.', status: 'in-progress' },
        { id: 3, title: 'Meet your manager', description: 'Schedule a meeting with your manager.', status: 'done' }
      ]
    }
  }
}
</script>

<style scoped>
.tasks-page {
  margin-left: 240px;
  padding: 2rem;
}
.tasks-list {
  display: flex;
  flex-wrap: wrap;
  gap: 1.5rem;
}
.task-card {
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 8px rgba(31,38,135,0.07);
  padding: 1.5rem;
  min-width: 250px;
  max-width: 320px;
}
.task-title {
  font-weight: bold;
  font-size: 1.1rem;
  margin-bottom: 0.5rem;
}
.task-desc {
  margin-bottom: 0.5rem;
}
.task-status {
  font-size: 0.95rem;
}
.task-status .pending {
  color: #e67e22;
}
.task-status .in-progress {
  color: #2980b9;
}
.task-status .done {
  color: #27ae60;
}
</style>
