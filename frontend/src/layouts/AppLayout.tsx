import {
  useState,
  type ForwardRefExoticComponent,
  type RefAttributes,
} from "react";
import {
  IconAutomation,
  IconChartHistogram,
  IconHome2,
  IconLogout,
  type IconProps,
} from "@tabler/icons-react";
import {
  AppShell,
  Center,
  Divider,
  Stack,
  Tooltip,
  UnstyledButton,
} from "@mantine/core";
import classes from "./AppLayout.module.css";
import { Outlet, useLocation, useNavigate } from "react-router";
import { useRequiredAuth } from "../features/auth/hooks";

interface NavbarLinkProps {
  icon: typeof IconHome2;
  label: string;
  active?: boolean;
  onClick?: () => void;
}

function NavbarLink({ icon: Icon, label, active, onClick }: NavbarLinkProps) {
  return (
    <Tooltip label={label} position="right" transitionProps={{ duration: 0 }}>
      <UnstyledButton
        onClick={onClick}
        className={classes.link}
        data-active={active || undefined}
        aria-label={label}
      >
        <Icon size={20} stroke={1.5} />
      </UnstyledButton>
    </Tooltip>
  );
}

interface Link {
  icon: ForwardRefExoticComponent<IconProps & RefAttributes<SVGSVGElement>>;
  label: string;
  slug: string;
}

const pages: Link[] = [
  { icon: IconHome2, label: "Home", slug: "/" },
  { icon: IconChartHistogram, label: "Finance", slug: "/finance" },
] as const;

export function AppLayout() {
  const navigate = useNavigate();
  const location = useLocation();
  const auth = useRequiredAuth();

  const [active, setActive] = useState<string>(location.pathname);

  const links = pages.map((link) => (
    <NavbarLink
      {...link}
      key={link.label}
      active={active === link.slug}
      onClick={() => {
        setActive(link.slug);
        navigate(link.slug);
      }}
    />
  ));

  return (
    <AppShell
      navbar={{
        width: 80,
        breakpoint: "sm",
      }}
    >
      <AppShell.Navbar>
        <nav className={classes.navbar}>
          <Center>
            <IconAutomation color="rgb(51, 154, 240)" />
          </Center>
          <Divider my="sm" />

          <div className={classes.navbarMain}>
            <Stack justify="center" gap={0}>
              {links}
            </Stack>
          </div>
          <Divider my="sm" />
          <Stack justify="center" gap={0}>
            <NavbarLink
              icon={IconLogout}
              label="Logout"
              onClick={async () => await auth.performLogout()}
            />
          </Stack>
        </nav>
      </AppShell.Navbar>
      <AppShell.Main>
        <Outlet />
      </AppShell.Main>
    </AppShell>
  );
}
