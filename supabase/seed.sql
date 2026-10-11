-- Solo para Supabase LOCAL (se ejecuta después de Database/schema.sql en "supabase start" / "supabase db reset").
-- Clave fija de desarrollo: no es secreta y no sirve en producción.
ALTER ROLE app_riobravo WITH LOGIN PASSWORD 'riobravo_local';
