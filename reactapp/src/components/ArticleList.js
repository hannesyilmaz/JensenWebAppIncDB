import React, { useState, useEffect } from 'react';

const ArticlesPage = () => {
    const [articles, setArticles] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetch('/home/article') // updated URL
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                console.log(data); // Logging the data.
                setArticles(data);
                setIsLoading(false);
            })
            .catch(error => {
                console.error(`Fetch operation error: ${error.message}`);
                setError(error.message);
                setIsLoading(false);
            });
    }, []);

    if (isLoading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    return (
        <div>
            <h1>Articles</h1>
            {articles.map((article, index) => (
                <div key={index}>
                    <h2>{article.title}</h2>
                    <p>{article.summary}</p>
                    <p>{article.published}</p>
                    <a href={article.link}>Read more</a>
                </div>
            ))}
        </div>
    );
}

export default ArticlesPage;
