import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import Button from '@mui/material/Button';

export default function ItemList({ items, onUpdate, onDelete, onSelectItem }) {
  return (
    <List>
      {items.map((item) => (
        <ListItem key={item.id} secondaryAction={
          <>
            <Button
              onClick={() => onSelectItem(item)} // Select item for editing
              variant="outlined"
              color="warning"
              size="small"
              style={{ marginRight: '8px' }}
            >
              Editar
            </Button>
            <Button
              onClick={() => onDelete(item.id)} // Delete item
              variant="outlined"
              color="error"
              size="small"
            >
              Deletar
            </Button>
          </>
        }>
          <ListItemText primary={item.name} />
        </ListItem>
      ))}
    </List>
  );
}
