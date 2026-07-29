import { AuthenticationForm } from "../features/auth/AuthenticationForm";
import { useForm } from "@mantine/form";
import type { AuthenticationFormValues } from "../features/auth/AuthenticationFormValues";
import { Navigate } from "react-router";
import { useAuth } from "../features/auth/hooks";

export function AuthenticationPage() {
  const auth = useAuth();

  const form = useForm<AuthenticationFormValues>({
    initialValues: {
      username: "",
      password: "",
    },
  });

  const handleSubmit = form.onSubmit(async (values) => {
    await auth.performLogin(values.username, values.password);
  });

  if (!auth.isLoading && auth.isLoggedIn) {
    return <Navigate to="/" />;
  }

  return (
    <form onSubmit={handleSubmit}>
      <AuthenticationForm form={form} isLoading={auth.isLoading} />
    </form>
  );
}
