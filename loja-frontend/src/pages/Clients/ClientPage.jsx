import { useEffect, useState } from 'react';
import CrudTable from '../../components/CrudTable';
import { getClients, addClient, updateClient, deleteClient } from '../../api/clientService';

export default function ClientPage() {
  const [clients, setClients] = useState([]);

  const fetchClients = async () => {
    try {
      const data = await getClients();
      setClients(data);
    } catch (error) {
      console.error('Erro ao buscar clientes:', error);
    }
  };

  useEffect(() => {
    fetchClients();
  }, []);

  return (
    <div style={{ padding: '16px' }}>
      <CrudTable
        items={clients}
        onAdd={async (item) => {
          await addClient(item);
          fetchClients();
        }}
        onUpdate={async (id, item) => {
          await updateClient(id, item);
          fetchClients();
        }}
        onDelete={async (id) => {
          await deleteClient(id);
          fetchClients();
        }}
      />
    </div>
  );
}
