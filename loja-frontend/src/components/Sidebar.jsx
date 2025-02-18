import { useState } from 'react';
import { Drawer, List, ListItem, ListItemText, Button } from '@mui/material';

export default function Sidebar({ setActivePage }) {
  const [showDropdown, setShowDropdown] = useState(false);

  return (
    <Drawer variant="permanent" anchor="left">
      <List>
        <ListItem>
          <Button onClick={() => setShowDropdown(!showDropdown)}>Categorias</Button>
        </ListItem>
        {showDropdown && (
          <>
            <ListItem button onClick={() => setActivePage('products')}>
              <ListItemText primary="Produtos" />
            </ListItem>
            <ListItem button onClick={() => setActivePage('clients')}>
              <ListItemText primary="Clientes" />
            </ListItem>
          </>
        )}
      </List>
    </Drawer>
  );
}
