import { useContext } from "react";
import { AuthenticationContext } from "./AuthenticationContext";

export function useAuth() {
  return useContext(AuthenticationContext);
}

export function useRequiredAuth() {
  const auth = useContext(AuthenticationContext);

  if (!auth.isLoggedIn) {
    throw new Error(
      "useRequiredAuth is expected to be used in a scenario where the user is authenticated",
    );
  }

  return auth;
}
