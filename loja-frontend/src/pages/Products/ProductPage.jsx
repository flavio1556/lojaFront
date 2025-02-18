import { useEffect, useState } from 'react';
import CrudTable from '../../components/CrudTable';
import { getProducts, addProduct, updateProduct, deleteProduct } from '../../api/productService';

export default function ProductPage() {
  const [products, setProducts] = useState([]);

  const fetchProducts = async () => {
    try {
      const data = await getProducts();
      setProducts(data);
    } catch (error) {
      console.error('Erro ao buscar produtos:', error);
    }
  };

  useEffect(() => {
    fetchProducts();
  }, []);

  return (
    <div style={{ padding: '16px' }}>
      <h2 style={{ marginBottom: '16px' }}>Produtos</h2>
      <CrudTable
        items={products}
        onAdd={async (item) => {
          await addProduct(item);
          fetchProducts();
        }}
        onUpdate={async (id, item) => {
          await updateProduct(id, item);
          fetchProducts();
        }}
        onDelete={async (id) => {
          await deleteProduct(id);
          fetchProducts();
        }}
      />
    </div>
  );
}