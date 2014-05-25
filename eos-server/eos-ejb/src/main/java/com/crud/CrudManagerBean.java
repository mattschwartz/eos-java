package com.eos.crud;

/**
 * Imports
 */
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.List;
import java.util.Map.Entry;
import java.util.Set;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.Id;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

/**
 * CrudServiceBean
 */
@Stateless
public class CrudManagerBean
{
    /**
     * Data
     */
    @PersistenceContext
    private EntityManager em;

    /**
     * Methods
     */    
    /**
     * Flush an object.
     *
     * @param o The object to flush.
     */
    public void flush()
    {
        em.flush();
    }
    
    /**
     * Flush an object.
     *
     * @param o The object to persist.
     */
    public <T> T persist(T t)
    {
        em.persist(t);
        
        return t;
    }

    /**
     * Creates and persists an entity data object. The returned object has it's
     *
     * @Id property set correctly.
     * @param <T> The type of entity data object.
     * @param t The object to persist.
     * @return The newly created object.
     */
    private <T> T create(T t)
    {
        em.persist(t);
        em.flush();
        em.refresh(t);

        return t;
    }

    /**
     * Saves a new or updates and existing instance of an entity data object
     *
     * @param <T> the entity object's type
     * @param t the entity object to persist
     * @return a managed reference to the object
     */
    public <T> T save(T t)
    {
        Class c = t.getClass();
        /* Find a method annotated with javax.persistence.Id */
        Method idMethod = AnnotationUtility.getFirstAnnotatedProperty(c, Id.class);
        /* Find a managed object by the Id or create a new one */
        T response = null;
        try {
            if (find(idMethod.invoke(t), c) != null) {
                response = update(t);
            } else {
                response = create(t);
            }
        } catch (InvocationTargetException ex) {
            throw new IllegalArgumentException("Class does not have a public no-arg id method", ex);
        } catch (IllegalAccessException ex) {
            throw new IllegalArgumentException("Class does not have a public no-arg id method", ex);
        }
        return response;
    }

    /**
     * Retrieves an entity data object. An exception is thrown if no matching
     * object is found.
     *
     * @param <T> The type of entity data object.
     * @param type The class of the entity data object.
     * @param id The primary key of the data object.
     * @return The matching entity.
     */
    public <T> T find(Class<T> type, Object id)
    {
        return (T) em.find(type, id);
    }

    /**
     * Retrieves an entity data object. An exception is thrown if no matching
     * object is found.
     *
     * @param <T> The type of entity data object.
     * @param type The class of the entity data object.
     * @param id The primary key of the data object.
     * @return The matching entity.
     */
    public <T> T find(Object id, Class<T> type)
    {
        return (T) em.find(type, id);
    }

    /**
     * Deletes the specified data object.
     *
     * @param t The object to delete.
     */
    public void delete(Object t)
    {
        Object ref = em.merge(t);
        em.remove(ref);
    }

    /**
     * Deletes a entity data object.
     *
     * @param id The primary key of the data object.
     * @param type The data object's class.
     */
    public void delete(Object id, Class type)
    {
        Object ref = em.getReference(type, id);
        em.remove(ref);
    }

    /**
     * Updates an unmanaged data object.
     *
     * @param <T> The type of the entity data object.
     * @param t The data object.
     * @return The merged, updated data object.
     */
    private <T> T update(T t)
    {
        return (T) em.merge(t);
    }

    /**
     * Gets a result list from a named query.
     *
     * @param <T> The type of object in the list.
     * @param namedQueryName The name of the named query.
     * @return The result list.
     */
    public <T> List<T> findByNamedQuery(String namedQueryName)
    {
        return em.createNamedQuery(namedQueryName)
                .getResultList();
    }

    /**
     * Gets a result list from a named query with parameters.
     *
     * @param <T> The type of object in the list.
     * @param namedQueryName The name of the named query.
     * @param parameters The query parameters.
     * @return The result list.
     */
    public <T> List<T> findByNamedQuery(String namedQueryName, QueryParameters parameters)
    {
        Set<Entry<String, Object>> rawParameters = parameters.getParameters().entrySet();

        Query query = em.createNamedQuery(namedQueryName);

        for (Entry<String, Object> entry : rawParameters) {
            query.setParameter(entry.getKey(), entry.getValue());
        }

        return query.getResultList();
    }

    /**
     * Gets a single result from a named query with parameters.
     *
     * @param <T> The type of object in the list.
     * @param namedQueryName The name of the named query.
     * @param parameters The query parameters.
     * @return The result.
     */
    public <T> T findSingleResultByNamedQuery(String namedQueryName, QueryParameters parameters)
    {
        Set<Entry<String, Object>> rawParameters = parameters.getParameters().entrySet();

        Query query = em.createNamedQuery(namedQueryName);

        for (Entry<String, Object> entry : rawParameters) {
            query.setParameter(entry.getKey(), entry.getValue());
        }

        return (T)query.getSingleResult();
    }

    /**
     * Executes a named query.
     *
     * @param namedQueryName The name of the named query.
     */
    public void executeNamedQuery(String namedQueryName)
    {
        em.createNamedQuery(namedQueryName)
                .executeUpdate();
    }

    /**
     * Executes a named query with parameters.
     *
     * @param namedQueryName The name of the named query.
     * @param parameters The query parameters.
     */
    public void executeNamedQuery(String namedQueryName, QueryParameters parameters)
    {
        Set<Entry<String, Object>> rawParameters = parameters.getParameters().entrySet();

        Query query = em.createNamedQuery(namedQueryName);

        for (Entry<String, Object> entry : rawParameters) {
            query.setParameter(entry.getKey(), entry.getValue());
        }

        query.executeUpdate();
    }
}
