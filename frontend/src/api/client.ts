import { useStoredCsrfToken } from "./csrf";

export async function apiFetch(
  input: Parameters<typeof fetch>[0],
  init?: Parameters<typeof fetch>[1],
) {
  const headers = new Headers(init?.headers);

  const method = init?.method?.toUpperCase() ?? "GET";

  if (!["GET", "HEAD", "OPTIONS"].includes(method)) {
    // eslint-disable-next-line react-hooks/rules-of-hooks
    headers.set("RequestVerificationToken", useStoredCsrfToken());
  }

  return fetch(input, {
    ...init,
    headers,
    credentials: "include",
  });
}
