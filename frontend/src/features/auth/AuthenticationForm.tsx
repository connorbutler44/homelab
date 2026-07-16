import {
  Button,
  Container,
  Paper,
  PasswordInput,
  TextInput,
  Title,
} from "@mantine/core";
import classes from "./AuthenticationTitle.module.css";
import type { UseFormReturnType } from "@mantine/form";
import type { AuthenticationFormValues } from "./AuthenticationFormValues";

interface Props {
  form: UseFormReturnType<AuthenticationFormValues>;
}

export function AuthenticationForm(props: Props) {
  const { form } = props;

  return (
    <Container size={420} my={40}>
      <Title ta="center" className={classes.title}>
        Sign In
      </Title>

      <Paper withBorder shadow="sm" p={22} mt={30} radius="md">
        <TextInput
          {...form.getInputProps("username")}
          key={form.key("username")}
          label="Username"
          placeholder="Username"
          required
          radius="md"
        />
        <PasswordInput
          {...form.getInputProps("password")}
          key={form.key("password")}
          label="Password"
          placeholder="Password"
          required
          mt="md"
          radius="md"
        />
        <Button fullWidth mt="xl" radius="md" type="submit">
          Sign in
        </Button>
      </Paper>
    </Container>
  );
}
