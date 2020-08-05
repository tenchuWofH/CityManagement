/* eslint-disable no-useless-constructor */
/* eslint-disable class-methods-use-this */
// import axios from 'axios';
import http from '../services/http-common';

import { City } from '../models/models';

// const baseUrl = 'api';
// const baseUrl = 'https://localhost:44347';

class CityService {
  constructor() {
    // console.log('creating new instance of cityService');
  }

  deleteCity(city: City) {
    // return axios.delete(`${baseUrl}/city/${city.cityId}`);
    return http.delete(`/city/${city.cityId}`);
  }

  getCities() {
    // // return axios.get<City[]>(`${baseUrl}/cities`);
    // return axios.get<City[]>(`${baseUrl}/city`);
    return http.get<City[]>('/city');
  }

  addCity(city: City) {
    // return axios.post(`${baseUrl}/city/`, { city });
    return http.post('/city/', { city });
  }

  updateCity(city: City) {
    // return axios.put(`${baseUrl}/city/${city.cityId}`, { city });
    return http.put(`/city/${city.cityId}`, { city });
  }
}

// Export a singleton instance in the global namespace
export const cityService = new CityService();
