package matcha.project.be.service;

import lombok.RequiredArgsConstructor;
import matcha.project.be.dao.CategoryDao;
import matcha.project.be.entity.CategoryEntity;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@RequiredArgsConstructor
public class CategoryService {
    private final CategoryDao categoryDao;

    public List<CategoryEntity> getAllCategories() {
        return categoryDao.findAll();
    }

}
