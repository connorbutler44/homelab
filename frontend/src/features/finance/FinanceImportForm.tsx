import { Button, Container, FileInput, NativeSelect } from "@mantine/core";
import { useForm } from "@mantine/form";
import { PROVIDERS } from "./financeTypes";
import { ApiRoutes } from "../../api/apiRoutes";
import { apiFetch } from "../../api/client";

interface FinanceImportFormValues {
  file: File;
  provider: keyof typeof PROVIDERS;
}

export function FinanceImportForm() {
  const form = useForm<FinanceImportFormValues>({});

  const handleSubmit = form.onSubmit(async (values) => {
    const formData = new FormData();

    formData.append("ProviderKey", values.provider);
    formData.append("File", values.file);

    apiFetch(ApiRoutes.ImportTransactions, {
      method: "POST",
      body: formData,
    })
      .then(console.log)
      .catch(console.error);
  });

  return (
    <Container size={420} my={40}>
      <form onSubmit={handleSubmit}>
        <NativeSelect
          {...form.getInputProps("provider")}
          label="Account"
          description="Which account to import transactions for"
          data={["", ...Object.keys(PROVIDERS)]}
          required
        />
        <FileInput
          {...form.getInputProps("file")}
          mt="md"
          label="Transactions"
          description="CSV containing transactions for the specified account"
          placeholder="data.csv"
          required
        />

        <Button fullWidth mt="xl" radius="md" type="submit">
          Import
        </Button>
      </form>
    </Container>
  );
}
