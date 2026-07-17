import "@mantine/core/styles.css";
import { MantineProvider } from "@mantine/core";
import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter, Route, Routes } from "react-router";
import { AuthenticationProvider } from "./features/auth/AuthenticationProvider.tsx";
import { AuthenticationPage } from "./pages/AuthenticationPage.tsx";
import { ProtectedRoute } from "./features/auth/ProtectedRoute.tsx";
import { DashboardPage } from "./pages/DashboardPage.tsx";
import { AppLayout } from "./layouts/AppLayout.tsx";
import { FinancePage } from "./pages/FinancePage.tsx";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <BrowserRouter>
      <AuthenticationProvider>
        <MantineProvider defaultColorScheme="dark">
          <Routes>
            <Route path="/login" element={<AuthenticationPage />} />
            <Route element={<ProtectedRoute />}>
              <Route element={<AppLayout />}>
                <Route path="/" element={<DashboardPage />} />
                <Route path="/finance" element={<FinancePage />} />
              </Route>
            </Route>
          </Routes>
        </MantineProvider>
      </AuthenticationProvider>
    </BrowserRouter>
  </StrictMode>,
);
