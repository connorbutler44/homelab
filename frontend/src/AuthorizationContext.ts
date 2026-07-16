import { createContext } from "react";

export interface User {
  username: string;
}

interface AuthorizationActions {
  isLoading: boolean;
  performLogin: (username: string, password: string) => Promise<void>;
  performLogout: () => Promise<void>;
}

interface LoggedInAuthorizationState {
  user: User;
  isLoggedIn: true;
}

interface LoggedOutAuthorizationState {
  isLoggedIn: false;
}

export type AuthorizationState =
  | LoggedInAuthorizationState
  | LoggedOutAuthorizationState;

export const AuthorizationContext = createContext<
  AuthorizationState & AuthorizationActions
>({
  isLoading: true,
  isLoggedIn: false,
  performLogin: async () => {},
  performLogout: async () => {},
});
