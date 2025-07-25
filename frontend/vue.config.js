const { defineConfig } = require('@vue/cli-service');

module.exports = defineConfig({
  transpileDependencies: true,
  devServer: {
    proxy: {
      '/api': {
        target: 'http://localhost:5028', // URL of your ASP.NET Core backend
        changeOrigin: true
      }
    }
  }
});