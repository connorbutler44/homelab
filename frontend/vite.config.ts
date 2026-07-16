import { defineConfig } from "vite";
import react, { reactCompilerPreset } from "@vitejs/plugin-react";
import babel from "@rolldown/plugin-babel";

// https://vite.dev/config/
export default defineConfig({
  plugins: [react(), babel({ presets: [reactCompilerPreset()] })],
  server: {
    proxy: {
      "/api": {
        target: "https://localhost:7011",
        changeOrigin: true,
        secure: false,
      },
      "/auth": {
        target: "https://localhost:7011",
        changeOrigin: true,
        secure: false,
      },
    },
  },
});
