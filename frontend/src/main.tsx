import "./index.css";
import "@mantine/core/styles.css";
import { MantineProvider } from "@mantine/core";
import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import App from "./App.tsx";
import { AuthenticationProvider } from "./features/auth/AuthenticationProvider.tsx";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <AuthenticationProvider>
      <MantineProvider defaultColorScheme="dark">
        <App />
      </MantineProvider>
    </AuthenticationProvider>
  </StrictMode>,
);
