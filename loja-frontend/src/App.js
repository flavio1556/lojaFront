// src/App.jsx
import { useState } from 'react';
import HeaderNavbar from './components/HeaderNavbar';
import Sidebar from './components/Sidebar';
import ProductPage from './pages/Products/ProductPage';
import ClientPage from './pages/Clients/ClientPage';

export default function App() {
  const [activePage, setActivePage] = useState('');

  return (
    <div style={{ display: 'flex', height: '100vh' }}>
      <Sidebar setActivePage={setActivePage} />
      <div style={{ flex: 1, display: 'flex', flexDirection: 'column' }}>
        <HeaderNavbar />
        {activePage === 'products' && <ProductPage />}
        {activePage === 'clients' && <ClientPage />}
      </div>
    </div>
  );
}