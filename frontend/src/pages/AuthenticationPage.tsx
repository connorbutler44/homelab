import { useContext } from "react";
import { AuthenticationForm } from "../features/auth/AuthenticationForm";
import { useForm } from "@mantine/form";
import { AuthenticationContext } from "../features/auth/AuthenticationContext";
import type { AuthenticationFormValues } from "../features/auth/AuthenticationFormValues";

export function AuthenticationPage() {
  const auth = useContext(AuthenticationContext);

  const form = useForm<AuthenticationFormValues>({
    initialValues: {
      username: "",
      password: "",
    },
  });

  const handleSubmit = form.onSubmit(async (values) => {
    await auth.performLogin(values.username, values.password);
  });

  return (
    <form onSubmit={handleSubmit}>
      <AuthenticationForm form={form} />
    </form>
  );
}
