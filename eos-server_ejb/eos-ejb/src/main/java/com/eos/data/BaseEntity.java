package com.eos.data;

/**
 * Imports
 */
import java.io.Serializable;

/**
 * BaseEntity
 */
public class BaseEntity implements Serializable
{
    /***
     * Data
     */
    protected int id;

    /**
     * Methods
     */
    @Override
    public boolean equals(Object o)
    {
        if (o == null || !getClass().equals(o.getClass())) {
            return false;
        }

        BaseEntity value = (BaseEntity) o;

        if (id == 0 || value.id == 0) {
            return false;
        }

        return id == value.id;
    }

    @Override
    public int hashCode()
    {
        return id;
    }

    @Override
    public String toString()
    {
        return getClass().getSimpleName() + "[ " + id + " ]";
    }
}
