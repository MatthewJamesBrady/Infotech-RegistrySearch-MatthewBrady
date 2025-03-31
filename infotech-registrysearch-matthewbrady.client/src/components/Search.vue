<template>
  <section>
    <div class="search-container">
      <h2>Search Tool</h2>
      <br />
      <div class="form-group">
        <label for="keywords">Keywords:</label>
        <input v-model="keywords" id="keywords" type="text" />
      </div>
      <br />
      <div class="form-group">
        <label for="searchUrl">Search URL:</label>
        <input v-model="searchUrl" id="searchUrl" type="text" />
      </div>

      <button @click="doSearch">Search</button>

      <div v-if="result" class="result">
        <h3>Result:</h3>

        <SearchResults :result ="result" :loading="loading" />
        
      </div>
        <div v-if="error">{{error }}</div>
    </div>
  </section>
</template>

<script>import SearchResults from './SearchResults.vue'

  export default {
    name: 'SearchBox',
    components: {
      SearchResults
    },
    data() {
      return {
        keywords: 'bbc',
        searchUrl: 'https://www.bbc.co.uk',
        result: null,
        loading: false,
        error: ''
      }
    },
    methods: {
      async doSearch() {
        try {
          this.loading = true;
          const response = await fetch('https://localhost:7197/api/search/dosearch', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
              phrase: this.keywords,
              url: this.searchUrl,
              engine: 'bing'
            })
          });

          if (!response.ok) throw new Error('Search failed');
          const data = await response.json();
          this.result = data;
        } catch (error) {
          this.error =  error.message  ;
        } finally {
          this.loading = false;
        }
      }
    }
  };</script>


<style>
  .search-container {
    width: 100%;
    height: 100%;
    min-height: 800px;
    min-width: 800px;
    max-width: 800px !important;
    margin: 2rem auto;
    padding: 1.5rem;
    background-color: #ffffff;
    border-radius: 8px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
    font-family: 'Segoe UI', sans-serif;
    color: #333; /* ensure text contrast */
  }

  .form-group {
    margin-bottom: 1.25rem;
  }

  label {
    display: block;
    font-weight: 600;
    font-size: 1rem;
    margin-bottom: 0.4rem;
    color: #222;
  }

  input {
    width: 100%;
    padding: 0.6rem;
    font-size: 1rem;
    border: 1px solid #ccc;
    border-radius: 4px;
  }

  button {
    margin-top: 1rem;
    padding: 0.6rem 1.2rem;
    font-size: 1rem;
    background-color: #2e86de;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
  }

    button:hover {
      background-color: #2167b6;
    }

  .result {
    margin-top: 2rem;
    background: #f4f4f4;
    padding: 1rem;
    border: 1px solid #ddd;
    border-radius: 6px;
    white-space: pre-wrap;
    font-family: monospace;
  }
</style>
