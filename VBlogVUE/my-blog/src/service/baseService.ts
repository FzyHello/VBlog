import axios, { AxiosInstance } from 'axios';

const instance: AxiosInstance = axios.create({
  baseURL: 'http://localhost:5214', // 设置基础URL
  timeout: 10000, // 设置超时时间
  headers: {
    'Content-Type': 'application/json',
  },
});

// 请求拦截器
instance.interceptors.request.use(
  (config) => {
    // 在请求发送之前做一些处理，例如添加 token
    const token = localStorage.getItem('token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

// 响应拦截器
instance.interceptors.response.use(
  (response) => {
    // 对响应数据做一些处理
    return response.data;
  },
  (error) => {
    // 对响应错误做一些处理
    return Promise.reject(error);
  }
);

// post 方法
export const Post = async<T>(url: string, data?: T) => {
  try {
    const response = await instance.post(url, data);
    return response;
  } catch (error: any) {
    throw new Error(error.response?.data?.message || error.message);
  }
};

// get 方法
export const Get = async<T>(url: string, params?: T) => {
  try {
    const response = await instance.get(url, { params });
    return response;
  } catch (error: any) {
    throw new Error(error.response?.data?.message || error.message);
  }
};

// del 方法
export const Delete = async<T>(url: string, params?: T) => {
  try {
    const response = await instance.delete(url, { data: params });
    return response;
  } catch (error:any) {
    throw new Error(error.response?.data?.message || error.message);
  }
};

// put 方法
export const Put = async<T>(url: string, data?: T) => {
  try {
    const response = await instance.put(url, data);
    return response;
  } catch (error:any) {
    throw new Error(error.response?.data?.message || error.message);
  }
};

export default instance;