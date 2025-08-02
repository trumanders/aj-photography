const API_BASE_URL = 'https://localhost:5173/api';

export async function fetchPhotosByCategory(category: string) {
    const response = await fetch(`${API_BASE_URL}/homepagephotos/category/${category}`);
    if (!response.ok) {
        throw new Error(`Failed to fetch photos ${response.statusText}`); 
    }

    return response.json();
}

