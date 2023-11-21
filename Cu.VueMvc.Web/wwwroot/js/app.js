let app = new Vue({
    el: "#app",
    data: {
        pageTitle: "Vue in Mvc",
        categoriesVisible: false,
        productsVisible: false,
        baseUrl: "https://localhost:44326/api",
        categories: [],
        hasError: false,
        errorMessage: "",
    },
    methods: {
        showCategories: async function () {
            this.hasError = false;
            this.productsVisible = false;
            this.categoriesVisible = true;
            //get the categories from the api
            this.categories = await axios.get(`${this.baseUrl}/categories`)
                .then(response => response.data.items)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found!";
                    }
                    this.hasError = true;
                });
        },
        showProducts: function () {
            this.categoriesVisible = false;
            this.productsVisible = true;
            //get the products from the api
        },
    },
});