## Dossier Pages

Comporte les routes/pages en accord avec la structure 

Le router va automatique pointer le domaine de base sur pages/index.tsx

### Route Enchainé

Si on crée des sous dossiers, le routeur va automatiquement avoir le nom de ces dossiers

ex : pages/blog/first-post.tsx -> /blog/first-post
ex : pages/dashboard/settings/username.js -> /dashboard/settings/username


### Route dynamique

pages/posts/[id].js  -> /posts/1