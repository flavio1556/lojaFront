import apiClient from './apiClient';

export const getProducts = async () => {
  try {
    const response = await apiClient.get('/produtos');
    return response.data;
  } catch (error) {
    console.error('Erro ao buscar produtos:', error);
    throw error;
  }
};

export const addProduct = async (product) => {
  try {
    const response = await apiClient.post('/produtos', product);
    return response.data;
  } catch (error) {
    console.error('Erro ao adicionar produto:', error);
    throw error;
  }
};

export const updateProduct = async (id, product) => {
  try {
    const response = await apiClient.put(`/produtos/${id}`, product);
    return response.data;
  } catch (error) {
    console.error('Erro ao atualizar produto:', error);
    throw error;
  }
};

export const deleteProduct = async (id) => {
  try {
    await apiClient.delete(`/produtos/${id}`);
  } catch (error) {
    console.error('Erro ao deletar produto:', error);
    throw error;
  }
};