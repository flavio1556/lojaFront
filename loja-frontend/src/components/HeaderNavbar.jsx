import { AppBar, Toolbar, Typography } from '@mui/material';

export default function HeaderNavbar() {
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6">Controle de Vendas</Typography>
      </Toolbar>
    </AppBar>
  );
}