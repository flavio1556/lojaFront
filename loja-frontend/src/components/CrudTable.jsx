import { useState } from 'react';
import { Box, Button } from '@mui/material';
import ItemForm from './ItemForm';
import ItemList from './ItemList';

export default function CrudTable({ items, onAdd, onUpdate, onDelete }) {
  const [selectedItem, setSelectedItem] = useState(null);

  const handleAdd = (newItem) => {
    onAdd(newItem);
  };

  const handleUpdate = (itemId, updatedItem) => {
    onUpdate(itemId, updatedItem);
    setSelectedItem(null); // Reset selected item after update
  };

  const handleDelete = (itemId) => {
    onDelete(itemId);
  };

  return (
    <Box>
      <ItemForm onAdd={handleAdd} onUpdate={handleUpdate} selectedItem={selectedItem} />
      <ItemList items={items} onUpdate={handleUpdate} onDelete={handleDelete} onSelectItem={setSelectedItem} />
    </Box>
  );
}
