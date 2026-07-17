import { Navigate, Outlet } from "react-router";
import { useAuth } from "./hooks";
import { LoadingOverlay } from "@mantine/core";

export function ProtectedRoute() {
  const auth = useAuth();

  if (auth.isLoading) {
    return <LoadingOverlay />;
  }

  if (!auth.isLoggedIn) {
    return <Navigate to="/login" replace />;
  }

  return <Outlet />;
}
