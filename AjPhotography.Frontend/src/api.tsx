const API_BASE_URL = 'https://localhost:7234/api';

export async function fetchPhotosByPageCategory(pageCategory: string) {
    const response = await fetch(`${API_BASE_URL}/photos/pageCategory/${pageCategory}`);
    if (!response.ok) {
        throw new Error(`Failed to fetch photos ${response.statusText}`); 
    }

    const data = await response.json();
    console.log('Fetched photos:', data); // Debugging line to check fetched data
    return data;
}

