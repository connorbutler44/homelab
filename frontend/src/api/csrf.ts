import { ApiRoutes } from "./apiRoutes";
import { apiFetch } from "./client";

const CSRF_TOKEN_KEY = "csrfToken";

export const requestCsrfToken = () => {
  apiFetch(ApiRoutes.GetCsrfToken).then(async (res) => {
    const { token } = await res.json();

    sessionStorage.setItem(CSRF_TOKEN_KEY, token);
  });
};

export const useStoredCsrfToken = () => {
  const csrfToken = sessionStorage.getItem(CSRF_TOKEN_KEY);

  if (!csrfToken) {
    throw new Error("CSRF token not defined");
  }

  return csrfToken;
};
