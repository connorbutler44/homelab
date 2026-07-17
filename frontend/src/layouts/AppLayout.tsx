import { useState } from "react";
import {
  IconChevronDown,
  IconLogout,
  IconUserCircle,
  IconAutomation,
} from "@tabler/icons-react";
import cx from "clsx";
import {
  Burger,
  Container,
  Divider,
  Drawer,
  Group,
  Menu,
  ScrollArea,
  Tabs,
  Text,
  UnstyledButton,
} from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import classes from "./AppLayout.module.css";
import { NavLink, Outlet, useLocation, useNavigate } from "react-router";
import { useRequiredAuth } from "../features/auth/hooks";

interface Tab {
  slug: string;
  label: string;
}

const tabs: Tab[] = [
  { label: "Dashboard", slug: "/" },
  { label: "Finance", slug: "/finance" },
];

export function AppLayout() {
  const navigate = useNavigate();
  const auth = useRequiredAuth();
  const location = useLocation();

  const [opened, { toggle, close }] = useDisclosure(false);
  const [userMenuOpened, setUserMenuOpened] = useState(false);

  const items = tabs.map((tab) => (
    <Tabs.Tab
      value={tab.slug}
      key={tab.slug}
      onClick={() => navigate(tab.slug)}
    >
      {tab.label}
    </Tabs.Tab>
  ));

  return (
    <>
      <div className={classes.header}>
        <Container className={classes.mainSection} size="md">
          <Group justify="space-between">
            <Group>
              <IconAutomation stroke={1} size={32} />
              <Text fw={800} size="xl" lh="1">
                Homelab
              </Text>
            </Group>
            <Burger
              opened={opened}
              onClick={toggle}
              hiddenFrom="xs"
              size="sm"
              aria-label="Toggle navigation"
            />

            <Menu
              width={260}
              position="bottom-end"
              transitionProps={{ transition: "pop-top-right" }}
              onClose={() => setUserMenuOpened(false)}
              onOpen={() => setUserMenuOpened(true)}
              withinPortal
            >
              <Menu.Target>
                <UnstyledButton
                  className={cx(classes.user, {
                    [classes.userActive]: userMenuOpened,
                  })}
                >
                  <Group gap={7}>
                    <IconUserCircle />
                    <Text fw={500} size="sm" lh={1} mr={3}>
                      {auth.user.username}
                    </Text>
                    <IconChevronDown size={12} stroke={1.5} />
                  </Group>
                </UnstyledButton>
              </Menu.Target>
              <Menu.Dropdown>
                <Menu.Item
                  leftSection={<IconLogout size={16} stroke={1.5} />}
                  onClick={async () => await auth.performLogout()}
                >
                  Logout
                </Menu.Item>
              </Menu.Dropdown>
            </Menu>
          </Group>
        </Container>
        <Container size="md">
          <Tabs
            defaultValue={location.pathname}
            variant="outline"
            visibleFrom="sm"
            classNames={{
              root: classes.tabs,
              list: classes.tabsList,
              tab: classes.tab,
            }}
          >
            <Tabs.List>{items}</Tabs.List>
            {items.map((item) => (
              <Tabs.Panel value={item.key!} key={item.key}>
                {" "}
              </Tabs.Panel>
            ))}
          </Tabs>
        </Container>

        <Drawer
          opened={opened}
          onClose={close}
          size="100%"
          padding="md"
          title="Navigation"
          hiddenFrom="xs"
          zIndex={1000000}
        >
          <ScrollArea h="calc(100vh - 80px" mx="-md">
            <Divider my="sm" />
            {tabs.map((tab) => (
              <NavLink
                to={tab.slug}
                key={tab.slug}
                className={classes.drawerLink}
              >
                {tab.label}
              </NavLink>
            ))}
          </ScrollArea>
        </Drawer>
      </div>
      <Outlet />
    </>
  );
}
