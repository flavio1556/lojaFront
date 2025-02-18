import { useEffect, useState } from 'react';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';


export default function ItemForm({ onAdd, onUpdate, selectedItem }) {
  const [item, setItem] = useState({ name: '' });

  useEffect(() => {
    if (selectedItem) {
      setItem({ name: selectedItem.name });
    }
  }, [selectedItem]);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (selectedItem) {
      onUpdate(selectedItem.id, item); // Update the selected item
    } else {
      onAdd(item); // Add new item
    }
    setItem({ name: '' }); // Clear the form
  };

  return (
    <form onSubmit={handleSubmit} style={{ marginBottom: '16px' }}>
      <TextField
        label={selectedItem ? 'Editar Item' : 'Novo Item'}
        value={item.name}
        onChange={(e) => setItem({ name: e.target.value })}
        variant="outlined"
        size="small"
      />
      <Button type="submit" variant="contained" color="primary" style={{ marginLeft: '8px' }}>
        {selectedItem ? 'Atualizar' : 'Adicionar'}
      </Button>
    </form>
  );
}
