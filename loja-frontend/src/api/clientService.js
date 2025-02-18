import apiClient from './apiClient';

export const getClients = async () => {
  try {
    const response = await apiClient.get('/clientes');
    return response.data;
  } catch (error) {
    console.error('Erro ao buscar clientes:', error);
    throw error;
  }
};

export const addClient = async (client) => {
  try {
    const response = await apiClient.post('/clientes', client);
    return response.data;
  } catch (error) {
    console.error('Erro ao adicionar cliente:', error);
    throw error;
  }
};

export const updateClient = async (id, client) => {
  try {
    const response = await apiClient.put(`/clientes/${id}`, client);
    return response.data;
  } catch (error) {
    console.error('Erro ao atualizar cliente:', error);
    throw error;
  }
};

export const deleteClient = async (id) => {
  try {
    await apiClient.delete(`/clientes/${id}`);
  } catch (error) {
    console.error('Erro ao deletar cliente:', error);
    throw error;
  }
};
