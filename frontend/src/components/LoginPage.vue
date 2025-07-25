<template>
  <div class="hais-login-root">
    <div class="hais-login-left">
      <div class="hais-welcome">
        <h1>Welcome to HAIS :)</h1>
        <img class="hais-illustration" src="https://assets10.lottiefiles.com/packages/lf20_yr6zz3wv.json" alt="Welcome Illustration" />
      </div>
    </div>
    <div class="hais-login-right">
      <div class="hais-login-form">
        <div class="hais-logo">high<span>(alt)</span></div>
        <h2>Login</h2>
        <form @submit.prevent="login">
          <div class="hais-input-group">
            <span class="hais-icon"><i class="fas fa-user"></i></span>
            <input v-model="email" type="email" placeholder="Username" required />
          </div>
          <div class="hais-input-group">
            <span class="hais-icon"><i class="fas fa-lock"></i></span>
            <input v-model="password" type="password" placeholder="Password" required />
            <span class="hais-icon hais-eye"><i class="fas fa-eye"></i></span>
          </div>
          <button type="submit">Login</button>
        </form>
        <div v-if="error" class="hais-error">{{ error }}</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'LoginPage',
  data() {
    return {
      email: '',
      password: '',
      error: ''
    }
  },
  methods: {
    async login() {
      this.error = '';
      try {
        const response = await fetch('/api/OpenProject/login', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({ email: this.email, password: this.password })
        });
        if (!response.ok) {
          const err = await response.text();
          this.error = err || 'Invalid username or password.';
          return;
        }
        const data = await response.json();
        // Save token if needed: localStorage.setItem('token', data.token);
        this.$emit('login-success', { email: data.user.email, role: data.user.role });
      } catch (e) {
        this.error = 'Login failed. Please try again.';
      }
    }
  }
}
</script>

<style scoped>
.hais-login-root {
  min-height: 100vh;
  display: flex;
  background: linear-gradient(120deg, #f8fbff 0%, #e0eafc 100%);
}
.hais-login-left {
  flex: 1.2;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding-left: 5vw;
}
.hais-welcome h1 {
  color: #1a7ca7;
  font-size: 2.5rem;
  margin-bottom: 2rem;
  font-weight: 700;
}
.hais-illustration {
  width: 350px;
  max-width: 90vw;
  margin-top: 1rem;
}
.hais-login-right {
  flex: 1;
  display: flex;
  align-items: center;
  justify-content: center;
}
.hais-login-form {
  background: #fff;
  border-radius: 16px;
  box-shadow: 0 8px 32px 0 rgba(31, 38, 135, 0.10);
  padding: 2.5rem 2.5rem 2rem 2.5rem;
  min-width: 350px;
  max-width: 400px;
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
}
.hais-logo {
  font-size: 1.5rem;
  font-weight: 700;
  color: #1a7ca7;
  margin-bottom: 2.5rem;
  letter-spacing: 1px;
}
.hais-logo span {
  color: #38b6ff;
}
h2 {
  color: #1a7ca7;
  margin-bottom: 2rem;
  font-weight: 600;
}
.hais-input-group {
  display: flex;
  align-items: center;
  background: #f5f7fa;
  border-radius: 8px;
  margin-bottom: 1.2rem;
  padding: 0.5rem 1rem;
  width: 100%;
  border: 1px solid #e0eafc;
}
.hais-input-group input {
  border: none;
  background: transparent;
  outline: none;
  font-size: 1rem;
  flex: 1;
  padding: 0.5rem 0.5rem;
}
.hais-icon {
  color: #1a7ca7;
  margin-right: 0.5rem;
  font-size: 1.1rem;
}
.hais-eye {
  margin-left: 0.5rem;
  cursor: pointer;
}
button {
  width: 100%;
  padding: 0.75rem;
  background: linear-gradient(90deg, #1a7ca7 0%, #38b6ff 100%);
  color: #fff;
  border: none;
  border-radius: 8px;
  font-size: 1rem;
  font-weight: bold;
  cursor: pointer;
  margin-top: 0.5rem;
  transition: background 0.2s;
}
button:hover {
  background: linear-gradient(90deg, #38b6ff 0%, #1a7ca7 100%);
}
.hais-error {
  color: #e74c3c;
  margin-top: 1rem;
  font-size: 0.95rem;
}
</style>
