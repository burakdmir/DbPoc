import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
Vue.use(Vuex);

const baseUrl = "https://localhost:44348/api";
const productsUrl = `${baseUrl}/ProductApi`;

//const testData = [];

//for (let i = 1; i <= 10; i++) {
//  testData.push({
//    id: i, name: `Product #${i}`, category: `Category ${i % 3}`,
//    description: `This is Product #${i}`, price: i * 50
//  })
//}

export default new Vuex.Store({
  strict: true,
  state: {
    products: []
  },
  mutations: {
    setData(state, data) {
      state.products = data.pData;
    }
  },
  actions: {
    async getData(context) {
      let pData = (await Axios.get(productsUrl)).data;
      context.commit("setData", { pData });
    }
  }
});
