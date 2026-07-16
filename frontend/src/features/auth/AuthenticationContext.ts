import { createContext } from "react";

export interface User {
  username: string;
}

interface AuthenticationActions {
  isLoading: boolean;
  performLogin: (username: string, password: string) => Promise<void>;
  performLogout: () => Promise<void>;
}

interface LoggedInAuthenticationState {
  user: User;
  isLoggedIn: true;
}

interface LoggedOutAuthenticationState {
  isLoggedIn: false;
}

export type AuthenticationState =
  | LoggedInAuthenticationState
  | LoggedOutAuthenticationState;

export const AuthenticationContext = createContext<
  AuthenticationState & AuthenticationActions
>({
  isLoading: true,
  isLoggedIn: false,
  performLogin: async () => {},
  performLogout: async () => {},
});
